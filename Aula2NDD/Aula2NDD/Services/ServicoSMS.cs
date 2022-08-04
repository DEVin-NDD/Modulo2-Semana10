using Aula2NDD.Infra;

namespace Aula2NDD.Services
{
    public class ServicoSMS
    {
        private readonly LogAcao _logAcao;

        public ServicoSMS(LogAcao logAcao)
        {
            _logAcao = logAcao;
        }

        public void Enviar(string texto)
        {
            // envio do sms

            _logAcao.GravarLog("SMS enviado com sucesso");
        }
    }
}
