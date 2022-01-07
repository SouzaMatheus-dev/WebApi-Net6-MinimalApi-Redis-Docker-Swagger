using Flunt.Notifications;
using Flunt.Validations;

namespace FrameworkChallenge.ViewModels
{
    public class EntryNumberViewModel : Notifiable<Notification>
    {
        public int Number { get; set; }

        public EntryNumber MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Number, "Informe um numero válido"));

            return new EntryNumber(Number);
        }
    }
}