using Acr.UserDialogs;
using Bit.ViewModel;
using System;
using System.Threading.Tasks;

namespace XamApp.ViewModels
{
    public class CodeVerifyViewModel : BitViewModelBase
    {
        public string FirstDigit { get; set; }

        public string SecondDigit { get; set; }
        public string ThirdDigit { get; set; }
        public string FourthDigit { get; set; }

        public BitDelegateCommand VerifyCommand { get; set; }

        public CodeVerifyViewModel()
        {
            VerifyCommand = new BitDelegateCommand(Verify);
        }

        public IUserDialogs UserDialogs { get; set; }

        public async Task Verify()
        {
            if (string.IsNullOrWhiteSpace(FirstDigit) || string.IsNullOrWhiteSpace(FirstDigit)
                || string.IsNullOrWhiteSpace(ThirdDigit) || string.IsNullOrWhiteSpace(FourthDigit))
            {
                await UserDialogs.AlertAsync(message: "Please provide the code!", title: ")-:", okText: "Ok!");
                return;
            }

            using (UserDialogs.Loading("Verifying the code...", maskType: MaskType.Black))
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
            }

            await NavigationService.NavigateAsync("/ServiceItems");
        }
    }
}
