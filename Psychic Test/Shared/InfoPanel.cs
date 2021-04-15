using Microsoft.AspNetCore.Components;
using Psychic_Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psychic_Test.Shared
{
    public class InfoPanel : ComponentBase , IDisposable
    {
        [Inject] public TestingGroup Group { get; set; }

        protected override void OnInitialized()
        {
            Group.On_Checked += Update;
            base.OnInitialized();
        }

        void Update()
        {
            StateHasChanged();
        }

        public void Dispose()
        {
            Group.On_Checked -= Update;
        }
    }
}
