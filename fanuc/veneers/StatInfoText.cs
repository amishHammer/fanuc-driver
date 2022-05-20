using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using l99.driver.@base;

namespace l99.driver.fanuc.veneers
{
    public class StatInfoText : Veneer
    {
        readonly Dictionary<Int32, string> _autText = new Dictionary<int, string>
        {
            { 0, "MDI" },
            { 1, "MEMory" },
            { 2, "****" },
            { 3, "EDIT" },
            { 4, "HaNDle" },
            { 5, "JOG" },
            { 6, "Teach in JOG" },
            { 7, "Teach in HaNDle" },
            { 8, "INC·feed" },
            { 9, "REFerence" },
            { 10, "ReMoTe" }
        };
        readonly Dictionary<Int32, string> _autText_15 = new Dictionary<Int32, string>
        {
            { 0, "****(No selection)"},
            { 1, "MDI"},
            { 2, "TAPE(Series 15), DNC(Series 15i)"},
            { 3, "MEMory"},
            { 4, "EDIT"},
            { 5, "TeacH IN"}
        };
        readonly Dictionary<Int32, string> _autText_16_Above = new Dictionary<Int32, string>
        {
            { 0, "MDI"},
            { 1, "MEMory"},
            { 2, "****"},
            { 3, "EDIT"},
            { 4, "HaNDle"},
            { 5, "JOG"},
            { 6, "Teach in JOG"},
            { 7, "Teach in HaNDle"},
            { 8, "INC-feed"},
            { 9, "REFerence"},
            { 10, "ReMoTe"},
            { 11, ""}
        };
        readonly Dictionary<Int32, string> _autText_16iW_18iW = new Dictionary<Int32, string>
{
            { 0, "MDI"},
            { 1, "MEMory"},
            { 2, "EDIT"},
            { 3, "HAND"},
            { 4, "JOG"},
            { 10, "TAPE"},
            { 11, "" }
};
        readonly Dictionary<Int32, string> _runText = new Dictionary<Int32, string>
        {
            { 0, "STOP"},
            { 1, "HOLD"},
            { 2, "STaRT"},
            { 3, "MSTR(jog mdi)"},
            { 4, "ReSTaRt(not blinking)"},
            { 5, "PRSR(program restart)"},
            { 6, "NSRC(sequence number search)"},
            { 7, "ReSTaRt(blinking)"},
            { 8, "ReSET"},
            { 9, "(Not used)"},
            { 10, "(Not used)"},
            { 11, "(Not used)"},
            { 12, "(Not used)"},
            { 13, "HPCC(during RISC operation)"},
        };
        readonly Dictionary<Int32, string> _runText_16_Above = new Dictionary<Int32, string>
        {
            { 0, "****(reset)"},
            { 1, "STOP"},
            { 2, "HOLD"},
            { 3, "STaRT"},
            { 4, "MSRT"},
            { 5, "" },
        };
        readonly Dictionary<Int32, string> _runText_16iW_18iW = new Dictionary<Int32, string>
        {
            { 0, "NOT READY"},
            { 1, "M-READY"},
            { 2, "C-START"},
            { 3, "F-HOLD"},
            { 4, "B-STOP"},
            { 5, "" },
        };
        readonly Dictionary<Int32, string> _editText = new Dictionary<Int32, string>
        {
            { 0, "****(Not editing)" },
            { 1, "EDIT" },
            { 2, "SeaRCH" },
            { 3, "VeRiFY" },
            { 4, "CONDense" },
            { 5, "READ" },
            { 6, "PuNCH" }
        };
        readonly Dictionary<Int32, string> _editText_16_Above_M = new Dictionary<Int32, string>
        {
            { 0, "****(Not editing)" },
            { 1, "EDIT" },
            { 2, "SeaRCH" },
            { 3, "OUTPUT" },
            { 4, "INPUT" },
            { 5, "COMPARE" },
            { 6, "Label SKip" },
            { 7, "ReSTaRt" },
            { 8, "HPCC" },
            { 9, "PTRR" },
            { 10, "RVRS" },
            { 11, "RTRY" },
            { 12, "RVED" },
            { 13, "HANDLE" },
            { 14, "OFfSeT" },
            { 15, "WorkOFfSet" },
            { 16, "AICC AI APC" },
            { 17, "MEmory-CHecK" },
            { 18, "CusToMer's BoarD" },
            { 19, "SAVE" },
            { 20, "AI NANO" },
            { 21, "AI APC" },
            { 22, "MBL APC" },
            { 23, "NANO HP AICC 2 AICC" },
            { 24, "AI HPCC" },
            { 25, "5-AXIS" },
            { 26, "LEN" },
            { 27, "RAD" },
            { 28, "WZR" },
            { 39, "TCP" },
            { 40, "TWP" },
            { 41, "TCP+TWP" },
            { 42, "APC" },
            { 43, "PRG-CHK" },
            { 44, "APC" }, //0i_D
            { 45, "S-TCP" },
            { 46, "AICC 2" },
            { 59, "ALLSAVE" },
            { 60, "NOTSAVE" },
            { 61, "" }
        };
        readonly Dictionary<Int32, string> _editText_16_Above_T = new Dictionary<Int32, string>
        {
            { 0, "****(Not editing)" },
            { 1, "EDIT" },
            { 2, "SeaRCH" },
            { 3, "OUTPUT" },
            { 4, "INPUT" },
            { 5, "COMPARE" },
            { 6, "Label SKip" },
            { 7, "OFfSeT" },
            { 8, "Work ShiFT" },
            { 9, "ReSTaRt" },
            { 10, "RVRS" },
            { 11, "RTRY" },
            { 12, "RVED" },
            { 14, "PTRR" },
            { 16, "AICC AI APC" },
            { 17, "MEmory-CHecK" },
            { 19, "SAVE" },
            { 20, "AI NANO" },
            { 21, "HPCC" },
            { 23, "NANO HP AICC 2 AICC" },
            { 24, "AI HPCC" },
            { 25, "5-AXIS" },
            { 26, "OFSX" },
            { 27, "OFSZ" },
            { 28, "WZR" },
            { 29, "OFSY" },
            { 31, "TOFS" },
            { 39, "TCP" },
            { 40, "TWP" },
            { 41, "TCP+TWP" },
            { 42, "APC" },
            { 43, "PRG-CHK" },
            { 44, "APC" }, //0i_D
            { 45, "S-TCP" },
            { 59, "ALLSAVE" },
            { 60, "NOTSAVE" },
            { 61, "" }
        };
        readonly Dictionary<Int32, string> _editText_16iW_18iW = new Dictionary<Int32, string>
        {
            { 0, "****(Not editing)" },
            { 1, "EDITING" },
            { 2, "SEARCH" },
            { 3, "RESTART" },
            { 4, "RETRACE" },
            { 5, "" },
        };

        readonly Dictionary<Int32, string> _motionText = new Dictionary<Int32, string>
        {
           { 0, "***" },
           { 1, "MoTioN" },
           { 2, "DWeLl" },
           { 3, "Wait (waiting:only TT)" }
        };
        readonly Dictionary<Int32, string> _motionText_16_Above = new Dictionary<Int32, string>
        {
           { 0, "***" },
           { 1, "MoTioN" },
           { 2, "DWeLl" },
           { 3, "" },
        };
        readonly Dictionary<Int32, string> _motionText_16iW_18iW = new Dictionary<Int32, string>
        {
           { 0, "***" },
           { 1, "CMTN" },
           { 2, "CDWL" },
           { 3, "" },
        };

        readonly Dictionary<Int32, string> _mstbText = new Dictionary<Int32, string>
        {
            { 0, "***" },
            { 1, "FIN" },
            { 2, "" }
        };
        readonly Dictionary<Int32, string> _mstbText_16iW_18iW = new Dictionary<Int32, string>
        {
            { 0, "***" },
            { 1, "CFIN" },
            { 2, "" }
        };
        readonly Dictionary<Int32, string> _emergencyText = new Dictionary<Int32, string>
        {
            { 0, "(Not emergency)" },
            { 1, "EMerGency" },
            { 2, "ReSET" },
            { 3, "WAIT(FS35i only)" }
        };
        readonly Dictionary<Int32, string> _emergencyText_16_Above = new Dictionary<Int32, string>
        {
            { 0, "(Not emergency)" },
            { 1, "EMerGency" },
            { 2, "ReSET" },
            { 3, "WAIT" },
            { 4, "" },
        };
        readonly Dictionary<Int32, string> _emergencyText_16iW_18iW = new Dictionary<Int32, string>
        {
            { 0, "" },
        };


        readonly Dictionary<Int32, string> _alarmText = new Dictionary<Int32, string>
        {
            { 0, "(No alarm)" },
            { 1,"ALarM" },
            { 2,"BATtery low" },
            { 3,"FAN(NC or Servo amplifier" },
            { 4,"PS Warning" },
            { 5,"FSsB warning" },
            { 6,"INSulate warning" },
            { 7,"ENCoder warning" },
            { 8,"PMC alarm" },
        };
        readonly Dictionary<Int32, string> _alarmText_16_Above = new Dictionary<Int32, string>
         {
            { 0,"***(Others)" },
            { 1,"ALarM" },
            { 2,"BATtery low" },
            { 3,"FAN(NC or Servo amplifier" },
            { 4,"PS Warning" },
            { 5,"FSsB warning" },
            { 6,"INSulate warning" },
            { 7,"ENCoder warning" },
            { 8,"PMC alarm" },
            { 9,"" },
        };
        readonly Dictionary<Int32, string> _alarmText_16iW_18iW = new Dictionary<Int32, string>
         {
            { 0,"(No alarm)" },
            { 1,"ALarM" },
            { 2,"BATtery low" },
            { 3,"" },
        };
        public StatInfoText(string name = "", bool isCompound = false, bool isInternal = false, Machine machine = null) : base(name, isCompound, isInternal, machine)
        {
            lastChangedValue = new
            {
                mode = new
                {
                    automatic = string.Empty,
                    manual = string.Empty
                },
                status = new
                {
                    run = string.Empty,
                    edit = string.Empty,
                    motion = string.Empty,
                    mstb = string.Empty,
                    emergency = string.Empty,
                    write = string.Empty,
                    label_skip = string.Empty,
                    alarm = string.Empty,
                    warning = string.Empty,
                    battery = string.Empty
                }
            };
        }
        
        protected override async Task<dynamic> AnyAsync(dynamic input, params dynamic?[] additionalInputs)
        {
            // TODO: evaluate text based on controller model
            FanucMachine machine = (FanucMachine)_machine;
            if (machine == null) { throw new Exception("Machine not set"); }
            if (!machine.SeenSysInfo) { throw new Exception("SysInfo not seen yet"); }
            int cm = 0;
            Int32.TryParse(machine.ControlModel, out cm);
            if (input.success)
            {
                var autArray = _autText;
                var runArray = _runText;
                var editArray = _editText;
                var motionArray = _motionText;
                var mstbArray = _mstbText;
                var emergencyArray = _emergencyText;
                var alarmArray = _alarmText;
                if (cm == 15) {
                    autArray = _autText_15;
                }
                if (cm >= 16)
                {
                    if (machine.ControlType.Equals(" W") && ( cm == 16 || cm == 18) )
                    {
                        autArray = _autText_16iW_18iW;
                        alarmArray = _alarmText_16iW_18iW;
                        editArray = _editText_16iW_18iW;
                        emergencyArray = _emergencyText_16iW_18iW;
                        motionArray = _motionText_16iW_18iW;
                        mstbArray = _mstbText_16iW_18iW;
                        runArray = _runText_16iW_18iW;
                    } else
                    {
                        autArray = _autText_16_Above;
                        alarmArray = _alarmText_16_Above;
                        emergencyArray = _emergencyText_16_Above;
                        motionArray = _motionText_16_Above;
                        runArray = _runText_16_Above;
                        if (machine.ControlType.EndsWith("M"))
                        {
                            editArray = _editText_16_Above_M;
                        } else if (machine.ControlType.EndsWith("T"))
                        {
                            editArray = _editText_16_Above_T;
                        }
                    }
                }
                
                
                var current_value = new
                {
                    mode = new
                    {
                        automatic = autArray[input.response.cnc_statinfo.statinfo.aut]
                        // manual ?
                    },
                    status = new
                    {
                        run = runArray[input.response.cnc_statinfo.statinfo.run],
                        edit = editArray[input.response.cnc_statinfo.statinfo.edit],
                        motion = motionArray[input.response.cnc_statinfo.statinfo.motion],
                        mstb = mstbArray[input.response.cnc_statinfo.statinfo.mstb],
                        emergency = emergencyArray[input.response.cnc_statinfo.statinfo.emergency],
                        alarm = alarmArray[input.response.cnc_statinfo.statinfo.alarm],
                    }
                };
                
                await onDataArrivedAsync(input, current_value);
                
                if (current_value.IsDifferentString((object)lastChangedValue))
                {
                    await onDataChangedAsync(input, current_value);
                }
            }
            else
            {
                await onErrorAsync(input);
            }

            return new { veneer = this };
        }
    }
}