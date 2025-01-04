using iText.Kernel.Pdf;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using RazorLight;
using System.Text;

namespace Print_html_project
{
    public partial class Form1 : Form
    {
        MemoryStream htmlStream = new();
        string outputHtmlPath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }


        public async void GerarHTML()
        {
            string templatePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "template.cshtml");
            if (!File.Exists(templatePath))
            {
                MessageBox.Show($"Arquivo não encontrado: {templatePath}");
                return;
            }
            var engine = new RazorLightEngineBuilder()
               .UseFileSystemProject(AppDomain.CurrentDomain.BaseDirectory)
               .UseMemoryCachingProvider()
               .Build();
            var model = new DataModel
            {
                IdBudget = 100,
                Decorator= "Maria",
                PhoneNumber="(27)99999-9999",
                Name = "João",
                Items = new List<Items>
                {
                    new Items { Date = new DateTime (2025,01,01), Description = "Venda", Price = 100.00 },
                    new Items { Date = new DateTime (2025,01,01), Description = "Venda", Price = 200.00 },
                    new Items { Date = new DateTime (2025,01,01), Description = "Venda", Price = 300.00 },

                }
            };
            try
            {
                string templateKey = "template.cshtml";
                string html = await engine.CompileRenderAsync(templateKey, model);
                outputHtmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorio.html");
                File.WriteAllText(outputHtmlPath, html);
                htmlStream.SetLength(0);

                // Gravando o HTML no MemoryStream
                using (StreamWriter writer = new StreamWriter(htmlStream, Encoding.UTF8, 1024, leaveOpen: true))
                {
                    await writer.WriteAsync(html);
                    await writer.FlushAsync();
                }
                MessageBox.Show("HTML gerado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar HTML: {ex.Message}");
            }

        }
        private void MesclarPdfs()
        {
            try
            {
                string pastaPdf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdf");

                string pdf1 = Path.Combine(pastaPdf, "pdf1.pdf");
                string pdf2 = Path.Combine(pastaPdf, "pdf2.pdf");
                string pdf3 = Path.Combine(pastaPdf, "pdf3.pdf");
                string pdf4 = Path.Combine(pastaPdf, "pdf4.pdf");
                string pdf5 = Path.Combine(pastaPdf, "pdf5.pdf");
                List<string> pdfFiles = new List<string> { pdf1, pdf2, pdf3, pdf4, pdf5 };
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Arquivos PDF (*.pdf)|*.pdf",
                    FileName = "pdf_mesclado.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pdfSaida = saveFileDialog.FileName;

                    // Mesclando os PDFs
                    using (PdfWriter writer = new PdfWriter(pdfSaida))
                    using (PdfDocument pdfDocSaida = new PdfDocument(writer))
                    {
                        foreach (var pdfFile in pdfFiles)
                        {
                            using (PdfReader reader = new PdfReader(pdfFile))
                            using (PdfDocument pdfDocEntrada = new PdfDocument(reader))
                            {
                                pdfDocEntrada.CopyPagesTo(1, pdfDocEntrada.GetNumberOfPages(), pdfDocSaida);
                            }
                        }
                    }

                    MessageBox.Show("PDFs mesclados com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao mesclar PDFs: {ex.Message}");
            }
        }

        private async Task GerarPdf2()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pdf");
                string outputPdfPath = Path.Combine(path, "pdf5.pdf");
                var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();

                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });

                var page = await browser.NewPageAsync();
                await page.GoToAsync($"file://{outputHtmlPath}");

                await page.PdfAsync(outputPdfPath, new PdfOptions
                {
                    Format = PaperFormat.A4,
                    PrintBackground = true,
                    MarginOptions = new MarginOptions
                    {
                        Top = "0",
                        Bottom = "0",
                        Left = "0",
                        Right = "0"
                    }
                });

                await browser.CloseAsync();

                MessageBox.Show("PDF gerado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o PDF: {ex.Message}");
            }
        }

        private void btnCarregarHtml_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri(outputHtmlPath);
        }

        private void btnGerarHtml_Click(object sender, EventArgs e)
        {
            GerarHTML();
        }

        private async void btnGerarPdf_Click(object sender, EventArgs e)
        {

            try
            {
                await GerarPdf2();
                MesclarPdfs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o PDF: {ex.Message}\n{ex.StackTrace}");
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.ShowPrintUI();
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
             GerarHTML();
        }
    }


}


