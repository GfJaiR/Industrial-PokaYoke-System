using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Net;
using System.Windows.Forms;

namespace Comparacion2024
{
    class ClsTelegram
    {
        static TelegramBotClient botClient;

        public async void sendMessageToTelegram(string telegram_ID, string msg)
        {
            try
            {
                botClient = new TelegramBotClient("6707095683:AAHAjTv5QAYnHuzqrHHI-BJ5mzSf9bM3PwE");
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                await botClient.SendTextMessageAsync(
                  chatId: telegram_ID,
                  text: msg
                );
            }
            catch (Exception)
            {
            }
        }
        public void Telegram(string user,string nomEs, string Pasta1, string Pasta2, string Stencil)
        {
            try
            {
                
                string strIDGrupo = "-1001971222363";
                string MensajeTelegram = "ERROR EN COMPARACION MPM\nNoEmpleado: " + user + "\nPasta1: " + Pasta1 + "\nPasta2: " + Pasta2 + "\nStencil: " + Stencil + "\nLINEA: " + nomEs  + "\nFECHA: " + DateTime.Now;
               sendMessageToTelegram(strIDGrupo, MensajeTelegram);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
