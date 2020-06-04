using Commercialobj.ApplicationServices.GetAdmAreaListUseCase;
using Commercialobj.ApplicationServices.Ports;
using Commercialobj.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Commercialobj.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetCommercialobjListUseCase _getCommercialobjListUseCase;

        public MainViewModel(IGetCommercialobjListUseCase getCommercialobjListUseCase)
            => _getCommercialobjListUseCase = getCommercialobjListUseCase;

        private Task<bool> _loadingTask;
        private commercialobj _currentCommercialobj;
        private ObservableCollection<commercialobj> _commercialobjs;

        public event PropertyChangedEventHandler PropertyChanged;

        public commercialobj CurrentCommercialobj
        {
            get => _currentCommercialobj; 
            set
            {
                if (_currentCommercialobj != value)
                {
                    _currentCommercialobj = value;
                    OnPropertyChanged(nameof(CurrentCommercialobj));
                }
            }
        }

        private async Task<bool> LoadCommercialobjs()
        {
            var outputPort = new OutputPort();
            bool result = await _getCommercialobjListUseCase.Handle(GetCommercialobjListUseCaseRequest.CreateAllCommercialobjsRequest(), outputPort);
            if (result)
            {
                Commercialobjs = new ObservableCollection<commercialobj>(outputPort.Commercialobjs);
            }
            return result;
        }

        public ObservableCollection<commercialobj> Commercialobjs
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadCommercialobjs();
                }
                
                return _commercialobjs; 
            }
            set
            {
                if (_commercialobjs != value)
                {
                    _commercialobjs = value;
                    OnPropertyChanged(nameof(Commercialobjs));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetCommercialobjListUseCaseResponse>
        {
            public IEnumerable<commercialobj> Commercialobjs { get; private set; }

            public void Handle(GetCommercialobjListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Commercialobjs = new ObservableCollection<commercialobj>(response.Commercialobjs);
                }
            }
        }
    }
}
