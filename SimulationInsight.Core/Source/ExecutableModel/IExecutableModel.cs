using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.Core;

public interface IExecutableModel
{
    void Initialise(double time);

    void Update(double time);

    void Finalise(double time);
}
