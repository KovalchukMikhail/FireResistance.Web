using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Core;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces
{
    internal interface IColumnFireIsWithFourSidesEquationsManager
    {
        public void RunPartFirstOfEquations(TempValuesForColumn values, ColumnFR column);

        public void RunPartSecondOfEquations(TempValuesForColumn values, ColumnFR column);

        public void RunPartThirdOfEquations(TempValuesForColumn values, ColumnFR column);

        public bool RunEquationEightDotTwentyThree(TempValuesForColumn values, ColumnFR column);
    }
}
