using System.Data;

namespace MP01;

public class ContainerShip {
    private Dictionary<String, Container> _containers = new Dictionary<String, Container>();

    private static double _maxSpeed = 16.0; //w węzłach
    private string _shipName;
    private double _speed;
    private double _maxContainersWeight;
    private int _maxContainerCapacity;
    private double _containersWeight;
    private int _containerCapacity;
    
    public ContainerShip(string name, double speed, double MaxContainerWeight, int MaxContainerCapacity) {
        SetShipName(name);
        SetSpeed(speed);
        SetMaxContainerWeight(MaxContainerWeight);
        SetMaxContainerCapacity(MaxContainerCapacity);
    }

    public void LoadContainer(Container container) {
        AddContainer(container);
    }

    public void LoadContainers(IEnumerable<Container> containers) {
        foreach (Container con in containers) {
            AddContainer(con);
        }
    }

    public void UnloadContainer(String containerName) {
        if (!_containers.ContainsKey(containerName)) {
            throw new Exception("Container not found: " + containerName);
        }
        RemoveContainer(containerName);
    }

    public void ChangeShip(ContainerShip second, string containerName) {
        second.AddContainer(_containers[containerName]);
        RemoveContainer(containerName);
    }

    public void SwitchContainer(string remove, Container add) {
        RemoveContainer(remove);
        AddContainer(add);
    }
    
    private void AddContainer(Container container) {
        if (_containersWeight + (container.GetEmptyWeight() + container.GetCargoWeight())/1000 > _maxContainersWeight) {
            throw new Exception("Container weight capacity exceeded.");
        }

        if (_containerCapacity >= _maxContainerCapacity) {
            throw new Exception("Container capacity exceeded.");
        }
        _containersWeight += (container.GetCargoWeight() + container.GetEmptyWeight())/1000;
        _containerCapacity++;
        _containers.Add(container.GetSerialNumber(), container);
    }

    private void RemoveContainer(string containerName) {
        _containersWeight -= (_containers[containerName].GetCargoWeight() + _containers[containerName].GetEmptyWeight())/1000;
        _containerCapacity--;
        _containers.Remove(containerName);
    }
    
    public void SetShipName(string name) {
        if (name == null) {
            throw new NoNullAllowedException("New name is a null");
        }

        if (name.Length == 0) {
            throw new ArgumentException("Name is an empty string");
        }
        _shipName = name;
    }

    public void SetSpeed(double speed) {
        if (speed > 16.0) {
            throw new ArgumentException("New speed is too big");
        }
        _speed = speed;
    }

    public void SetMaxContainerWeight(double maxContainerWeight) {
        if (maxContainerWeight < 0) {
            throw new ArgumentException("MaxContainerWeight is negative");
        }
        _maxContainersWeight = maxContainerWeight;
    }

    public void SetMaxContainerCapacity(int maxContainerCapacity) {
        if (maxContainerCapacity < 0) {
            throw new ArgumentException("MaxContainerCapacity is negative");
        }
        _maxContainerCapacity = maxContainerCapacity;
    }

    public override string ToString() {
        return
            $"{nameof(_shipName)}: {_shipName}, {nameof(_speed)}: {_speed}, {nameof(_maxContainersWeight)}: {_maxContainersWeight}, {nameof(_maxContainerCapacity)}: {_maxContainerCapacity}, {nameof(_containersWeight)}: {_containersWeight}, {nameof(_containerCapacity)}: {_containerCapacity}";
    }

    public void Show() {
        Console.WriteLine("Ship info:\n" + this + "\nContainers:");
        foreach (Container con in _containers.Values) {
            Console.WriteLine(con);
        }
    }
}