using CandidateTesting.JaderMartins.Exceptions;
using CandidateTesting.JaderMartins.Interfaces;
using CandidateTesting.JaderMartins.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Factories
{
    public static class FactoryFormat
    {
        public enum E_In
        {
            MinhaCdn = 1
        }

        public enum E_Out
        {
            Agora = 1
        }
        public static IOutFormat Criar(E_In p_In, E_Out p_Out)
        {
            if (p_In == E_In.MinhaCdn && p_Out == E_Out.Agora)
            {
                var instancia = new MinhaCdn();
                return new AgoraExport(instancia, instancia, instancia, instancia, instancia, instancia, instancia,instancia);
            }
            throw new ExceptionFactory();
        }
    }
}
