using SimulationInsight.MathLibrary;

namespace SimulationInsight.TrackingLibrary;

public interface IKalmanFilter
{
    int NumberOfStates { get; set; }

    double LastUpdateTime { get; set; }

    Vector X { get; set; }

    Matrix P { get; set; }

    Matrix Phi { get; set; }

    Matrix Q { get; set; }

    Vector XPred { get; set; }

    Matrix PPred { get; set; }

    Vector Z { get; set; }

    Matrix R { get; set; }

    Vector ZPred { get; set; }

    Matrix H { get; set; }

    Vector Y { get; set; }

    Matrix S { get; set; }

    Matrix K { get; set; }

    void Initalise(double time, Vector x, Matrix P);

    void Update(double time, Vector z, Matrix R);

    (Vector XPred, Matrix PPred) Predict(double time);

    Matrix StateTransitionMatrix(double dt);

    Matrix ProcessNoiseMatrix(double dt);

    Vector MeasurementVector(Vector xPred);

    Matrix MeasurementMatrix(Vector xPred);
}