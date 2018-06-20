
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VerificaBase
{
    public class TxtFastReport
    {
        string dirCaidTemp;
        string dirArquivoTxt;
        StreamWriter str;
        bool status = false;

        public bool Status
        {
            get{ return status; } set{ status = value; }
        }

        public TxtFastReport()
        {
            dirCaidTemp = Environment.GetEnvironmentVariable("CAIDTEMP");
            if (!string.IsNullOrEmpty(dirCaidTemp))
            {
                if (dirCaidTemp.Last() != '\\')
                    dirCaidTemp = dirCaidTemp + '\\';

                try
                {
                    dirArquivoTxt = dirCaidTemp + ((((DateTime.Now.ToString()).Replace(' ', '_') + ".txt")
                                                                            .Replace('/', '-'))
                                                                            .Replace(':', '-')).ToUpper();
                    str = new StreamWriter(@dirArquivoTxt, false, Encoding.ASCII);
                    str.WriteLine("ESTADO|UG|CNPJ|ENDERECO|TELEFONE|EMAIL|RODAPE");
                    str.WriteLine("X|X|9|X|9|X|Agili Software para Area Publica");
                    Status = true;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    Status = false;
                }
            }
            else
            {
                MessageBox.Show("Variável de ambiente CAIDTEMP não localizada!");
                Status = false;
            }
        }

        public bool GeraGrupoPadraoTitulo(string titulo, string[] campos, string[] tipos, string[] valores)
        {
            try
            {
                //TITULO
                str.WriteLine(titulo + "|GRUPO_PADRAO_TITULO");
                //CAMPOS
                str.WriteLine(ArrayStringToStringPorPipe(campos));
                //TIPOS
                str.WriteLine(ArrayStringToStringPorPipe(tipos));
                //VALORES
                str.WriteLine(ArrayStringToStringPorPipe(valores));

                return true;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool GeraNovoGrupo(string nomeGrupo, string[] campos, string[] tipos, string[] valores)
        {
            try
            {
                //NOME GRUPO
                str.WriteLine(nomeGrupo + "|" + nomeGrupo);
                //CAMPOS
                str.WriteLine(ArrayStringToStringPorPipe(campos));
                //TIPOS
                str.WriteLine(ArrayStringToStringPorPipe(tipos));
                //VALORES
                str.WriteLine(ArrayStringToStringPorPipe(valores));

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        string ArrayStringToStringPorPipe(string[] arrayString)
        {
            string texto = string.Empty;
            foreach (var e in arrayString)
            {
                if (string.IsNullOrEmpty(texto))
                    texto = e.ToString();
                else
                    texto = texto + "|" + e.ToString();
            }
            return texto;
        }
    }
}
