﻿namespace fanuc.veneers
{
    public class RdDynamic2 : Veneer
    {
        public RdDynamic2(string name = "") : base(name)
        {
            _lastValue = new
            {
                actual_feedrate = -1,
                actual_spindle_speed = -1,
                alarm = -1,
                main_program = -1, 
                current_program = -1, 
                sequence_number = -1
            };
        }
        
        protected override dynamic Any(dynamic input)
        {
            if (input.success)
            {
                dynamic d = input.response.cnc_rddynamic2.rddynamic;
                
                var current_value = new
                {
                    d.actf,
                    d.acts,
                    d.alarm,
                    d.prgmnum,
                    d.prgnum,
                    d.seqnum,
                    d.pos
                };
                
                if (!current_value.Equals(_lastValue))
                {
                    this.dataChanged(input, current_value);
                }
            }
            else
            {
                onError(input);
            }

            return new { veneer = this };
        }
    }
}