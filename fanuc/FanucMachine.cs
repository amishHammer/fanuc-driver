using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using l99.driver.@base;

namespace l99.driver.fanuc
{
    public class FanucMachine : Machine
    {
        public bool SeenSysInfo { get; set; }

        public string ControlType { get; set; }
        public string ControlModel { get; set; }

        public override string ToString()
        {
            return new
            {
                Id,
                _focasEndpoint.IPAddress,
                _focasEndpoint.Port,
                _focasEndpoint.ConnectionTimeout
            }.ToString();
        }

        public override dynamic Info
        {
            get
            {
                return new
                {
                    _id = id,
                    _focasEndpoint.IPAddress,
                    _focasEndpoint.Port,
                    _focasEndpoint.ConnectionTimeout
                };
            }
        }

        public FocasEndpoint FocasEndpoint
        {
            get => _focasEndpoint;
        }
        
        private FocasEndpoint _focasEndpoint;
        
        public FanucMachine(Machines machines, bool enabled, string id, object config) : base(machines, enabled, id, config)
        {
            SeenSysInfo = false;
            dynamic cfg = (dynamic) config;
            _focasEndpoint = new FocasEndpoint(cfg.type["net_ip"], (ushort)cfg.type["net_port"], (short)cfg.type["net_timeout_s"]);
            this["platform"] = new Platform(this);
        }
    }
}