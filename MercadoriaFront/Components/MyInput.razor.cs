using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MercadoriaFront.Components
{
    public class MyInputComponent : ComponentBase
    {
        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public bool Disabled { get; set; } = false;

        [Parameter]
        public InputType Type { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        protected async Task OnChangeAsync(ChangeEventArgs e)
        {
            Value = e.Value as string;
            await ValueChanged.InvokeAsync(Value);
        }
    }

    public enum InputType
    {
        Text = 0,
        Email = 1,
        Url = 2,
        Tel = 3
    }
}