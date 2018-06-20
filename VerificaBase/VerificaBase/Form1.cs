using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VerificaBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelecionarCfg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "cfg files (*.cfg)|*.cfg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.OpenFile() != null)
                    {
                        txtCfg.Text = openFileDialog1.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na leitura do arquivo selecionado!" + ex.Message);
                }
            }
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (txtCfg.Text != string.Empty)
            {
                List<Arquivo> listaArquivos = new List<Arquivo>();
                List<Arquivo> listaArquivosDuplicados = new List<Arquivo>();

                var varDRN = ObterVariaveisCFG(@txtCfg.Text, "drn");
                var varDRL = ObterVariaveisCFG(@txtCfg.Text, "drl");
                var varDRTC = ObterVariaveisCFG(@txtCfg.Text, "drtc");
                var varNCA = ObterVariaveisCFG(@txtCfg.Text, "nca");
                
                if (varDRN.Count() != 0)
                {
                    Console.WriteLine("DRN: " + varDRN.First());
                }
                else
                {
                    MessageBox.Show("Variavel de ambiente DRN não encontrada do arquivo CFG selecionado! " +
                                    "Processamento não será executado." +
                                    Environment.NewLine + " Arquivo CFG: " + txtCfg.Text);
                }

                if (varDRL.Count() != 0)
                {
                    Console.WriteLine("DRL: " + varDRL.First());
                }
                else
                {
                    MessageBox.Show("Variavel de ambiente DRL não encontrada do arquivo CFG selecionado! " +
                                    "Processamento não será executado." +
                                    Environment.NewLine + " Arquivo CFG: " + txtCfg.Text);
                }

                if (varDRTC.Count() != 0)
                {
                    Console.WriteLine("DRTC: " + varDRTC.First());
                }
                else
                {
                    MessageBox.Show("Variavel de ambiente DRTC não encontrada do arquivo CFG selecionado!" +
                                    Environment.NewLine + " Arquivo CFG: " + txtCfg.Text);
                }

                if (varNCA.Count() != 0)
                {
                    Console.WriteLine("NCA: " + varNCA.First());
                }
                else
                {
                    MessageBox.Show("Variavel de ambiente NCA não encontrada do arquivo CFG selecionado!" +
                                    " Processamento não será executado." +
                                    Environment.NewLine + " Arquivo CFG: " + txtCfg.Text);
                }

                if(varDRN.Count() != 0 && varDRL.Count() != 0 && varNCA.Count() != 0)
                {
                    //COMUM
                    if(Directory.Exists(varDRN.First() + @"\agili\comum\" + @varNCA.First() + @"\dat\"))
                    {
                        var dirComumDat = Directory.EnumerateFiles(varDRN.First() + @"\agili\comum\" + @varNCA.First() + @"\dat\", "*.dat");
                        foreach(var x in dirComumDat)
                        {
                            listaArquivos.Add(new Arquivo() { NomeCompleto = x , Nome = x.Split('\\').LastOrDefault() });
                        }
                    }

                    //CONTAGIL
                    if (Directory.Exists(varDRN.First() + @"\agili\contagil\" + @varNCA.First() + @"\dat\"))
                    {
                        var dirContagilDat = Directory.EnumerateFiles(varDRN.First() + @"\agili\contagil\" + @varNCA.First() + @"\dat\", "*.dat");
                        foreach (var x in dirContagilDat)
                        {
                            listaArquivos.Add(new Arquivo() { NomeCompleto = x, Nome = x.Split('\\').LastOrDefault() });
                        }
                    }

                    //GUARDIAO
                    if (Directory.Exists(varDRN.First() + @"\agili\guardiao\" + @varNCA.First() + @"\dat\"))
                    {
                        var dirGuardiaoDat = Directory.EnumerateFiles(varDRN.First() + @"\agili\guardiao\" + @varNCA.First() + @"\dat\", "*.dat");
                        foreach (var x in dirGuardiaoDat)
                        {
                            listaArquivos.Add(new Arquivo() { NomeCompleto = x, Nome = x.Split('\\').LastOrDefault() });
                        }
                    }

                    //RECEITAS
                    if (Directory.Exists(varDRN.First() + @"\agili\receitas\" + @varNCA.First() + @"\dat\"))
                    {
                        var dirReceitasDat = Directory.EnumerateFiles(varDRN.First() + @"\agili\receitas\" + @varNCA.First() + @"\dat\", "*.dat");
                        foreach (var x in dirReceitasDat)
                        {
                            listaArquivos.Add(new Arquivo() { NomeCompleto = x, Nome = x.Split('\\').LastOrDefault() });
                        }
                    }

                    //PONTUAL
                    if (Directory.Exists(varDRN.First() + @"\agili\pontual\" + @varNCA.First() + @"\dat\"))
                    {
                        var dirPontualDat = Directory.EnumerateFiles(varDRN.First() + @"\agili\Pontual\" + @varNCA.First() + @"\dat\", "*.dat");
                        foreach (var x in dirPontualDat)
                        {
                            listaArquivos.Add(new Arquivo() { NomeCompleto = x, Nome = x.Split('\\').LastOrDefault() });
                        }
                    }

                    if(listaArquivos.Count > 0)
                    {
                        TxtFastReport txtFastReport = new TxtFastReport();
                        if (txtFastReport.Status)
                        {
                            string[] valores = new string[] { };

                            valores[0] = "ARQUIVO";
                            valores[1] = "CAMINHO COMPLETO";
                            txtFastReport.GeraGrupoPadraoTitulo("DIVERGÊNCIAS DA BASE DE DADOS",
                                                                new string[] { "TIT-CAMPO-ARQUIVO", "TIT-CAMPO-CAMINHO" },
                                                                new string[] { "STRING", "STRING" },
                                                                valores);

                            //Flavio continuar aqui!!!!!!!!!!!
                            //Console.WriteLine(Environment.NewLine + "ARQUIVOS LOCALIZADOS" + Environment.NewLine);
                            //str.WriteLine("ARQUIVOS LOCALIZADOS");

                            valores = new string[] { };
                            foreach (var elemento in listaArquivos.GroupBy(x => x.Nome)
                                                  .Select(grupo => new {
                                                      Nome = grupo.Key,
                                                      Count = grupo.Count()
                                                  }).OrderBy(x => x.Nome))
                            {
                                //Console.WriteLine("Arquivo: {0} - Quantidade Localizada: {1}" ,
                                //                  elemento.Nome.ToUpper() , elemento.Count);
                                //str.WriteLine("Arquivo: {0} - Quantidade Localizada: {1}" ,
                                //                  elemento.Nome.ToUpper() , elemento.Count);

                                //flavio continuar aqui
                                //valores[cont] = elemento.Nome.ToUpper();
                                //valores[cont] = elemento.Count.ToString();
                                //cont++;

                                if (elemento.Count > 1)
                                {
                                    foreach (var arq in listaArquivos.Where(x => x.Nome.Equals(elemento.Nome)))
                                    {
                                        listaArquivosDuplicados.Add(arq);
                                    }
                                }
                            }

                            txtFastReport.GeraNovoGrupo("ARQUIVOS-LOCALIZADOS",
                                                        new string[] { "ARQ-LOC-NOME", "ARQ-LOC-QTD-LOCALIZADA" },
                                                        new string[] { "STRING", "INT" },
                                                        );

                            Console.WriteLine(Environment.NewLine + "###########################################################");
                            str.WriteLine(Environment.NewLine + "###########################################################");

                            if (listaArquivosDuplicados.Count > 0)
                            {
                                string nomeArquivo = String.Empty;
                                Console.WriteLine(Environment.NewLine + "ARQUIVOS DUPLICADOS");
                                str.WriteLine(Environment.NewLine + "ARQUIVOS DUPLICADOS");

                                foreach (var elemento in listaArquivosDuplicados.OrderBy(x => x.Nome))
                                {
                                    if (!nomeArquivo.Equals(elemento.Nome))
                                    {
                                        nomeArquivo = elemento.Nome;
                                        Console.WriteLine(Environment.NewLine + "Arquivo: " + nomeArquivo.ToUpper());
                                        str.WriteLine(Environment.NewLine + "Arquivo: " + nomeArquivo.ToUpper());
                                    }
                                    Console.WriteLine(elemento.NomeCompleto.ToUpper());
                                    str.WriteLine(elemento.NomeCompleto.ToUpper());
                                }
                            }
                        }
                        else
                            MessageBox.Show("Erro ao tentar gerar arquivo TXT para impressão do relatório!");
                    }else
                        MessageBox.Show("Nenhum arquivo DAT encontrado!");
                }
            }
            else
            {
                MessageBox.Show("Arquivo de configuração CFG não selecionado!");
            }
        }

        private static IEnumerable<string> ObterVariaveisCFG(string @arqCFG, string variavel)
        {
            return (from line in File.ReadAllLines(@arqCFG)
                    where
                        line.StartsWith(variavel, StringComparison.InvariantCultureIgnoreCase)
                   select
                        line.ToLowerInvariant().Split(' ').Last()).Distinct();
        }

        //exemplo dinâmico de como buscar variaveis de ambiente ################################################################
        //private static IEnumerable<string> ObterNCAS(System.IO.DirectoryInfo agili)
        //{
        //    return (from D in agili.GetDirectories("*cfg*", System.IO.SearchOption.AllDirectories)
        //            from F in D.GetFiles("*.cfg", System.IO.SearchOption.AllDirectories)
        //            from L in System.IO.File.ReadAllLines(F.FullName)
        //            where
        //                 L.StartsWith("nca", StringComparison.InvariantCultureIgnoreCase)
        //            select
        //                 L.ToLowerInvariant().Split(' ').Last()).Distinct();
        //}
        //######################################################################################################################
    }
}
