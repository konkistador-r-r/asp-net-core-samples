﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class M4UserInterface : UserInterface, IPollable
    {
        private CoffeeMakerAPI api;
        public M4UserInterface(CoffeeMakerAPI api)
        {
            this.api = api;
        }
        public void Poll()
        {
            BrewButtonStatus buttonStatus = api.GetBrewButtonStatus();
            if (buttonStatus == BrewButtonStatus.PUSHED)
            {
                StartBrewing();
            }
        }
        public override void Done()
        {
            api.SetIndicatorState(IndicatorState.ON);
        }
        public override void CompleteCycle()
        {
            api.SetIndicatorState(IndicatorState.OFF);
        }
    }}
