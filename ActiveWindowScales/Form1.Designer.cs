namespace ActiveWindowScales
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnGeneraScript = new System.Windows.Forms.Button();
            this.iconizarApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMostrarAplicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInicarServicio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDetenerServicio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGenerarScriptHost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCerrarAplicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(39, 41);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(98, 49);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(158, 41);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(98, 49);
            this.btnDetener.TabIndex = 1;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMensaje.Location = new System.Drawing.Point(36, 107);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(202, 24);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "Servicio por iniciar...";
            // 
            // btnGeneraScript
            // 
            this.btnGeneraScript.Location = new System.Drawing.Point(0, -1);
            this.btnGeneraScript.Name = "btnGeneraScript";
            this.btnGeneraScript.Size = new System.Drawing.Size(92, 26);
            this.btnGeneraScript.TabIndex = 3;
            this.btnGeneraScript.Text = "Generar Script";
            this.btnGeneraScript.UseVisualStyleBackColor = true;
            this.btnGeneraScript.Visible = false;
            // 
            // iconizarApp
            // 
            this.iconizarApp.ContextMenuStrip = this.mnuContextual;
            this.iconizarApp.Icon = ((System.Drawing.Icon)(resources.GetObject("iconizarApp.Icon")));
            this.iconizarApp.Text = "notifyIcon1";
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMostrarAplicacion,
            this.toolStripSeparator1,
            this.mnuInicarServicio,
            this.mnuDetenerServicio,
            this.mnuGenerarScriptHost,
            this.toolStripSeparator2,
            this.mnuCerrarAplicacion});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(177, 126);
            // 
            // mnuMostrarAplicacion
            // 
            this.mnuMostrarAplicacion.Name = "mnuMostrarAplicacion";
            this.mnuMostrarAplicacion.Size = new System.Drawing.Size(176, 22);
            this.mnuMostrarAplicacion.Text = "Abrir ";
            this.mnuMostrarAplicacion.Click += new System.EventHandler(this.mnuMostrarAplicacion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuInicarServicio
            // 
            this.mnuInicarServicio.Name = "mnuInicarServicio";
            this.mnuInicarServicio.Size = new System.Drawing.Size(176, 22);
            this.mnuInicarServicio.Text = "Iniciar Servicio";
            this.mnuInicarServicio.Click += new System.EventHandler(this.mnuInicarServicio_Click);
            // 
            // mnuDetenerServicio
            // 
            this.mnuDetenerServicio.Name = "mnuDetenerServicio";
            this.mnuDetenerServicio.Size = new System.Drawing.Size(176, 22);
            this.mnuDetenerServicio.Text = "Detener Servicio";
            this.mnuDetenerServicio.Click += new System.EventHandler(this.mnuDetenerServicio_Click);
            // 
            // mnuGenerarScriptHost
            // 
            this.mnuGenerarScriptHost.Name = "mnuGenerarScriptHost";
            this.mnuGenerarScriptHost.Size = new System.Drawing.Size(176, 22);
            this.mnuGenerarScriptHost.Text = "Generar Script Host";
            this.mnuGenerarScriptHost.Click += new System.EventHandler(this.mnuGenerarScriptHost_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuCerrarAplicacion
            // 
            this.mnuCerrarAplicacion.Name = "mnuCerrarAplicacion";
            this.mnuCerrarAplicacion.Size = new System.Drawing.Size(176, 22);
            this.mnuCerrarAplicacion.Text = "Cerrar";
            this.mnuCerrarAplicacion.Click += new System.EventHandler(this.mnuCerrarAplicacion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.btnGeneraScript);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Agent Talma Scales";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.mnuContextual.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnGeneraScript;
        private System.Windows.Forms.NotifyIcon iconizarApp;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem mnuMostrarAplicacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuInicarServicio;
        private System.Windows.Forms.ToolStripMenuItem mnuDetenerServicio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarAplicacion;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerarScriptHost;
    }
}

