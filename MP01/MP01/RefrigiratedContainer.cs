namespace MP01;

public class RefrigiratedContainer : Container {
    private double _temperature;
    private string _foodType;

    public RefrigiratedContainer(double temperature, String food) : base(ContainerType.C) {
        CheckForFood(food);
        _temperature = temperature;
        _foodType = food;
    }

    public void LoadContainer(double load, string foodType) {
        if (_foodType != foodType) {
            throw new ArgumentException("Container contains different food type.");
        }

        if (_temperature < Food.Foods[foodType]) {
            throw new ArgumentException("Container temperature is out of range.");
        }
        
        CheckForFood(foodType);
        
        base.LoadContainer(load);
    }

    private void CheckForFood(String foodType) {
        if (!Food.Foods.ContainsKey(foodType)) {
            throw new ArgumentException("Provided invalid food type.");
        }
    }
}

public class Food {
    
    public static Dictionary<String, double> Foods = new Dictionary<String, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15.0},
        {"Ice cream", -18.0},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausage", 5.0},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
}