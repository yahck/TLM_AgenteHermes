using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace HermesProcessAgent
{
    internal class SingletonControllerM : MarshalByRefObject
    {
        private static TcpChannel m_TCPChannel;

        private static Mutex m_Mutex;

        private static SingletonControllerM.ReceiveDelegate m_Receive;

        public static SingletonControllerM.ReceiveDelegate Receiver
        {
            get
            {
                return SingletonControllerM.m_Receive;
            }
            set
            {
                SingletonControllerM.m_Receive = value;
            }
        }

        static SingletonControllerM()
        {
            SingletonControllerM.m_TCPChannel = null;
            SingletonControllerM.m_Mutex = null;
            SingletonControllerM.m_Receive = null;
        }


        public SingletonControllerM()
        {
        }

        public static void Cleanup()
        {
            if (SingletonControllerM.m_Mutex != null)
            {
                SingletonControllerM.m_Mutex.Close();
            }
            if (SingletonControllerM.m_TCPChannel != null)
            {
                SingletonControllerM.m_TCPChannel.StopListening(null);
            }
            SingletonControllerM.m_Mutex = null;
            SingletonControllerM.m_TCPChannel = null;
        }

        private static void CreateInstanceChannel()
        {
            try
            {
                SingletonControllerM.m_TCPChannel = new TcpChannel(1614);
                ChannelServices.RegisterChannel(SingletonControllerM.m_TCPChannel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("HermesProcessAgent.SingletonController"), "SingletonController", WellKnownObjectMode.SingleCall);
            }
            catch
            {
            }
        }


        public static bool IamFirst(SingletonControllerM.ReceiveDelegate r)
        {
            bool flag;
            if (!SingletonControllerM.IamFirst())
            {
                flag = false;
            }
            else
            {
                SingletonControllerM.Receiver = (SingletonControllerM.ReceiveDelegate)Delegate.Combine(SingletonControllerM.Receiver, r);
                flag = true;
            }
            return flag;
        }

        public static bool IamFirst()
        {
            bool flag;
            string codeBase = Assembly.GetExecutingAssembly().GetName(false).CodeBase;
            string str = codeBase.Replace("\\", "_");
            SingletonControllerM.m_Mutex = new Mutex(false, str);
            if (!SingletonControllerM.m_Mutex.WaitOne(1, true))
            {
                SingletonControllerM.m_Mutex.Close();
                SingletonControllerM.m_Mutex = null;
                flag = false;
            }
            else
            {
                SingletonControllerM.CreateInstanceChannel();
                flag = true;
            }
            return flag;
        }

        public void Receive(string[] s)
        {
            if (SingletonControllerM.m_Receive != null)
            {
                SingletonControllerM.m_Receive(s);
            }
        }

        public static void Send(string[] s)
        {
            SingletonControllerM obj;
            ChannelServices.RegisterChannel(new TcpChannel(), false);
            try
            {
                obj = (SingletonControllerM)Activator.GetObject(typeof(SingletonControllerM), "tcp://localhost:1614/SingletonController");
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Concat("Exception: ", exception.Message));
                throw;
            }
            try
            {
                obj.Receive(s);
            }
            catch
            {
            }
        }

        public delegate void ReceiveDelegate(string[] args);

    }
}
