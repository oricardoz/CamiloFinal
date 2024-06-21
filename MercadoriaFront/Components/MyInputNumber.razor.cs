using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MercadoriaFront.Components
{
    public class MyInputNumberComponent : ComponentBase
    {
        private double value;

        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public double Value 
        { 
            get => value; 
            set
            {
                 if (this.value != value)
                 {
                    this.value = value;
                    ValueChanged.InvokeAsync(value);
                 }
            }
        }

        [Parameter]
        public bool Disabled { get; set; } = false;

        [Parameter]
        public InputType Type { get; set; }

        [Parameter]
        public EventCallback<double> ValueChanged { get; set; }
    }
}