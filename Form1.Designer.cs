namespace Print_html_project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnImprimir = new Button();
            btnGerarPdf = new Button();
            btnGerarHtml = new Button();
            btnCarregarHtml = new Button();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView.BackColor = SystemColors.ButtonHighlight;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(68, 96);
            webView.Name = "webView";
            webView.Size = new Size(861, 417);
            webView.TabIndex = 0;
            webView.ZoomFactor = 1D;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(336, 28);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnGerarPdf
            // 
            btnGerarPdf.Location = new Point(512, 28);
            btnGerarPdf.Name = "btnGerarPdf";
            btnGerarPdf.Size = new Size(75, 23);
            btnGerarPdf.TabIndex = 2;
            btnGerarPdf.Text = "Gerar pdf";
            btnGerarPdf.UseVisualStyleBackColor = true;
            btnGerarPdf.Click += btnGerarPdf_Click;
            // 
            // btnGerarHtml
            // 
            btnGerarHtml.Location = new Point(68, 28);
            btnGerarHtml.Name = "btnGerarHtml";
            btnGerarHtml.Size = new Size(119, 23);
            btnGerarHtml.TabIndex = 3;
            btnGerarHtml.Text = "Gerar HTML";
            btnGerarHtml.UseVisualStyleBackColor = true;
            btnGerarHtml.Click += btnGerarHtml_Click;
            // 
            // btnCarregarHtml
            // 
            btnCarregarHtml.Location = new Point(210, 28);
            btnCarregarHtml.Name = "btnCarregarHtml";
            btnCarregarHtml.Size = new Size(105, 23);
            btnCarregarHtml.TabIndex = 4;
            btnCarregarHtml.Text = "Carregar HTML";
            btnCarregarHtml.UseVisualStyleBackColor = true;
            btnCarregarHtml.Click += btnCarregarHtml_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 549);
            Controls.Add(btnCarregarHtml);
            Controls.Add(btnGerarHtml);
            Controls.Add(btnGerarPdf);
            Controls.Add(btnImprimir);
            Controls.Add(webView);
            Name = "Form1";
            Text = "Form1";
            Load +=  Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Button button1;
        private Button btnImprimir;
        private Button btnGerarPdf;
        private Button btnGerarHtml;
        private Button btnCarregarHtml;
    }
}
