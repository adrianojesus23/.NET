using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APP.Pages
{
    public class PlayerGModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IPlayerGenerator _playerGenerator;
        public Player player { get; set; }

        public PlayerGModel(ILogger<PrivacyModel> logger, IPlayerGenerator playerGenerator)
        {
            _logger = logger;
            _playerGenerator = playerGenerator;
        }

        public void OnGet()
        {
            player = _playerGenerator.CreateNewPlayer();
        }
    }
}
