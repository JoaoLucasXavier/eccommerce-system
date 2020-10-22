using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notifications
{
    public class Notifies
    {
        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        public List<Notifies> Notifications;

        public Notifies()
        {
            Notifications = new List<Notifies>();
        }

        public bool ValidateStringProperty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo obrigatório",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }

        public bool ValidateIntegerProperty(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo obrigatório",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }

        public bool ValidateDecimalProperty(decimal value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo obrigatório",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }
    }
}
