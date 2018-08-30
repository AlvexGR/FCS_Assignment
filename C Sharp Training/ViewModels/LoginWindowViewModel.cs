using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReactiveUI;
using Npgsql;
using C_Sharp_Training.DataAccess;

namespace C_Sharp_Training.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private string pin;
        private int curIndex;

        public string Pin
        {
            get { return pin; }
            set { this.RaiseAndSetIfChanged(ref pin, value); }
        }
        
        public ReactiveCommand<Unit, Unit> ClearPinCommand { get; protected set; }
        public ReactiveCommand<char, Unit> RecieveInputCommand { get; protected set; }
        public ReactiveCommand<Unit, bool> ValidatePinCommand { get; protected set; }

        public LoginWindowViewModel()
        {
            pin = "----";
            curIndex = 0;
            ClearPinCommand = ReactiveCommand.Create(ClearPin);
            RecieveInputCommand = ReactiveCommand.Create<char>(UpdatePin);
            ValidatePinCommand = ReactiveCommand.Create(ValidatePin);
        }

        /// <summary>
        /// Clear the current pin's content
        /// </summary>
        private void ClearPin()
        {
            curIndex = 0;
            Pin = "----";
        }

        /// <summary>
        /// Update the pin at index = curIndex with PressedButton
        /// </summary>
        private void UpdatePin(char c)
        {
            if (curIndex == 4) // reached the end but the input pin is incorrect => we do nothing
            {
                MessageBox.Show("Your input pin is incorrect!");
                return;
            }
            // update the current location with char c
            StringBuilder sb = new StringBuilder(Pin);
            sb[curIndex++] = c;
            Pin = sb.ToString();
            if (curIndex == 4) // reaches the end, validates the pin
            {
                ValidatePinCommand.Execute().Subscribe();
            }
        }

        /// <summary>
        /// Validate the input pin to see if it is correct or not
        /// </summary>
        private bool ValidatePin()
        {
            bool ans = UserDataAccess.VerifyUserByPin(pin);
            if (!ans)
            {
                MessageBox.Show("Your input pin is incorrect!");
            }
            return ans;
        }
    }
}
