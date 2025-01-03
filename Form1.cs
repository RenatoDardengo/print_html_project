using RazorLight;

namespace Print_html_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Caminho do template
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template.cshtml");
            if (!File.Exists(templatePath))
            {
                MessageBox.Show($"Arquivo não encontrado: {templatePath}");
                return;
            }

            // Cria a engine RazorLight
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(AppDomain.CurrentDomain.BaseDirectory) // Diretório do arquivo cshtml
                .UseMemoryCachingProvider()
                .Build();

            // Simulo dados do modelo
            var model = new DataModel
            {
                Name = "João",
                Items = new List<Items>
        {
            new Items { Date = "2025-01-01", Description = "Venda", Price = "R$ 100,00" },
            new Items { Date = "2025-01-01", Description = "Venda", Price = "R$ 100,00" },
            new Items { Date = "2025-01-01", Description = "Venda", Price = "R$ 100,00" },
            new Items { Date = "2025-01-02", Description = "Serviço", Price = "R$ 200,00" }
        }
            };

            // Renderiza o HTML
            string templateKey = "template.cshtml"; 
            try
            {
                string html = await engine.CompileRenderAsync(templateKey, model);

                // Salvar o HTML gerado
                string outputHtmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorio.html");
                File.WriteAllText(outputHtmlPath, html);

                // Renderizar no WebView2
                webView.Source = new Uri(outputHtmlPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao renderizar o template: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.ShowPrintUI();
        }
    }
}
