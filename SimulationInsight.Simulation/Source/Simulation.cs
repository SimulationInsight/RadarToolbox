﻿using SimulationInsight.Ais.Server;
using SimulationInsight.Core;
using SimulationInsight.DataRecorder;
using SimulationInsight.Radar;
using SimulationInsight.ScenarioGenerator;
using SimulationInsight.SimdisInterface;

namespace SimulationInsight.Simulation;

public class Simulation : ISimulation
{
    public ISimulationSettings SimulationSettings
    {
        get;
        set;
    }

    public IScenarioSettings ScenarioSettings
    {
        get;
        set;
    }

    public IAisServer AisServer
    {
        get;
        set;
    }

    public IDataRecorderSettings DataRecorderSettings
    {
        get;
        set;
    }

    public IScenario Scenario
    {
        get;
        set;
    }

    public ISystemClock SystemClock
    {
        get;
        set;
    }

    public IRadar Radar
    {
        get;
        set;
    }

    public IDataRecorder DataRecorder
    {
        get;
        set;
    }

    public ISimdisDataExporter SimdisDataExporter
    {
        get;
        set;
    }

    public Simulation(ISimulationSettings simulationSettings, IScenarioSettings scenarioSettings, IAisServer aisServer, IDataRecorderSettings dataRecorderSettings, IScenario scenario, ISystemClock systemClock, IRadar radar, IDataRecorder dataRecorder, ISimdisDataExporter simdisDataExporter)
    {
        SimulationSettings = simulationSettings;
        ScenarioSettings = scenarioSettings;
        AisServer = aisServer;
        DataRecorderSettings = dataRecorderSettings;

        Scenario = scenario;
        SystemClock = systemClock;
        Radar = radar;
        DataRecorder = dataRecorder;
        SimdisDataExporter = simdisDataExporter;
    }

    public void Run()
    {
        Logger.Information("Simulation Started...");
        Logger.Information("");

        InitialiseClock();

        var time = SystemClock.CurrentTime;

        InitialiseSimulation(time);

        RunSimulation(time);

        FinaliseSimulation(time);

        WriteData();

        Logger.Information("Simulation Finished.");
        Logger.Information("");
    }

    public void InitialiseClock()
    {
        SystemClock.DateTimeOrigin = SimulationSettings.SimulationStartDateTime;

        SystemClock.CurrentTime = SimulationSettings.StartTime;
    }

    public void InitialiseSimulation(double time)
    {
        Logger.Information("   Initialising Simulation...");

        AisServer.GetAisData();

        Initialise(time);

        Logger.Information("   Finished.");
        Logger.Information("");
    }

    public void RunSimulation(double time)
    {
        Logger.Information("   Running Simulation...");

        while (time < SimulationSettings.EndTime)
        {
            Logger.Information($"      Time = {time:0000.000}s");

            Update(time);

            time += SimulationSettings.TimeStep;
        }

        Logger.Information("   Finished.");
        Logger.Information("");
    }

    public void FinaliseSimulation(double time)
    {
        Logger.Information("   Finalising Simulation...");

        Finalise(time);

        Logger.Information("   Finished.");
        Logger.Information("");
    }

    public void WriteData()
    {
        Logger.Information("   Writing Output Data...");

        WriteDataRecorderData();
        WriteSimdisData();

        Logger.Information("   Finished.");
        Logger.Information("");
    }

    public void Initialise(double time)
    {
        SystemClock.Initialise(time);
        Scenario.GenerateScenario();
        Radar.Initialise(time);
    }

    public void Update(double time)
    {
        SystemClock.Update(time);
        Radar.Update(time);
    }

    public void Finalise(double time)
    {
        SystemClock.Finalise(time);
        Radar.Finalise(time);
    }

    public void WriteDataRecorderData()
    {
        DataRecorder.WriteData();
    }

    public void WriteSimdisData()
    {
        var fileName = DataRecorder.GetFullFileName("Simdis", ".asi");

        SimdisDataExporter.WriteAsiData(fileName);
    }
}