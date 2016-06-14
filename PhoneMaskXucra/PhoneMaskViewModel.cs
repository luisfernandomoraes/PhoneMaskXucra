using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneMaskXucra
{
    public class PhoneMaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        char[] specialChars = { '*', '#' };

        private string _phoneNumber;
        public PhoneMaskViewModel()
        {
            //_phoneNumber = "545454";
        }


        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = FormatText(value);
                OnPropertyChanged(nameof(PhoneNumber));
            }

        }

        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            StringBuilder builder = new StringBuilder();
            str.Where(char.IsDigit).ToList().ForEach(x => builder.Append(x));
            str = builder.ToString();
            string formatted = string.Empty;


            if (hasNonNumbers)
            {
                return "";
            }


            switch (str.Count(char.IsDigit))
            {
                case 0:
                    break;
                case 1:
                case 2:
                    formatted = $"({str}) - ";
                    break;
                case 3:
                case 4:
                    formatted = $"({str.Substring(0,2)}) - {str.Substring(2)}";
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    formatted = $"({str.Substring(0, 2)}) - {str.Substring(2)}";
                    break;
                case 10:
                    formatted = $"({str.Substring(0, 2)} ) {str.Substring(2, 4)} - {str.Substring(6, 4)}";//SC
                    break;
                case 11:
                    formatted = $"({str.Substring(0, 2)} ) {str.Substring(2, 5)} - {str.Substring(6, 4)}";//SP
                    break;
                case 12:
                    formatted = $"({str.Substring(0, 3)}) {str.Substring(3, 6)} - {str.Substring(6, 4)}";//USA
                    break;

                default:
                    formatted = _phoneNumber;
                    break;


            }

            return formatted;
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
