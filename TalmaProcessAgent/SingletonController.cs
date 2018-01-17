using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace HermesProcessAgent
{
    internal class SingletonController : MarshalByRefObject
    {
        private static TcpChannel m_TCPChannel;

        private static Mutex m_Mutex;

        private static SingletonController.ReceiveDelegate m_Receive;

        public static SingletonController.ReceiveDelegate Receiver
        {
            get
            {
                return SingletonController.m_Receive;
            }
            set
            {
                SingletonController.m_Receive = value;
            }
        }

        static SingletonController()
        {
            SingletonController.m_TCPChannel = null;
            SingletonController.m_Mutex = null;
            SingletonController.m_Receive = null;
        }

        public SingletonController()
        {
        }

        public static void Cleanup()
        {
            if (SingletonController.m_Mutex != null)
            {
                SingletonController.m_Mutex.Close();
            }
            if (SingletonController.m_TCPChannel != null)
            {
                SingletonController.m_TCPChannel.StopListening(null);
            }
            SingletonController.m_Mutex = null;
            SingletonController.m_TCPChannel = null;
        }

        private static void CreateInstanceChannel()
        {
            try
            {
                SingletonController.m_TCPChannel = new TcpChannel(1614);
                ChannelServices.RegisterChannel(SingletonController.m_TCPChannel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("HermesProcessAgent.SingletonController"), "SingletonController", WellKnownObjectMode.SingleCall);
            }
            catch
            {
            }
        }

        public static bool IamFirst(SingletonController.ReceiveDelegate r)
        {
            bool flag;
            if (!SingletonController.IamFirst())
            {
                flag = false;
            }
            else
            {
                SingletonController.Receiver = (SingletonController.ReceiveDelegate)Delegate.Combine(SingletonController.Receiver, r);
                flag = true;
            }
            return flag;
        }

        public static bool IamFirst()
        {
            bool flag;
            string codeBase = Assembly.GetExecutingAssembly().GetName(false).CodeBase;
            string str = codeBase.Replace("\\", "_");
            SingletonController.m_Mutex = new Mutex(false, str);
            if (!SingletonController.m_Mutex.WaitOne(1, true))
            {
                SingletonController.m_Mutex.Close();
                SingletonController.m_Mutex = null;
                flag = false;
            }
            else
            {
                SingletonController.CreateInstanceChannel();
                flag = true;
            }
            return flag;
        }

        public delegate void ReceiveDelegate(string[] args);
    }
}
