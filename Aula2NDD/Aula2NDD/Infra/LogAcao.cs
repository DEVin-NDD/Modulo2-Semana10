namespace Aula2NDD.Infra
{
    public class LogAcao
    {
        public static int ContadorInicializacoes = 0;

        public string CaminhoArquivo { get; set; }

        public LogAcao(string caminhoArquivo)
        {
            CaminhoArquivo = caminhoArquivo;

            ContadorInicializacoes++;
        }

        public void GravarLog(string texto)
        {
            //Aqui gravaria o log no arquivo
        }
    }
}
