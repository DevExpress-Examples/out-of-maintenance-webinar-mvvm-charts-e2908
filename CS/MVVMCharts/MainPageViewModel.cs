using System.Windows.Input;

namespace MVVMCharts {

    public class MainPageViewModel {
        public MainPageViewModel() {
            RandomizeTeamCommand = new DelegateCommand(RandomizeTeam, CanRandomizeTeam);
        }

        private void RandomizeTeam(object param) {
            _CurrentTeam.GenerateNewNumbers();
        }

        private bool CanRandomizeTeam(object param) {
            return true;
        }

        Team _CurrentTeam = new Team();
        public Team CurrentTeam {
            get { return _CurrentTeam; }
        }
        public ICommand RandomizeTeamCommand { get; set; }
    }
}
