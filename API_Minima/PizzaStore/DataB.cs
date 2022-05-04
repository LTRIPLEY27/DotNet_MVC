using System;
namespace PizzaStore.DB;

public record Pizza
{   // DEFINICIÒN OBJETO PIZZA
	public int Id { get; set; }
	public string? Name { get; set; }
}

public class PizzaDB
{
	private static List<Pizza> _pizzas = new List<Pizza>()
	{// INSTANCIAS PIZZA EN LA BASE DE DATOS
		new Pizza() { Id = 1, Name = "Montemagno, Pizza shaped like a great mountain"},
		new Pizza() { Id = 2, Name = "Donnatello"},
		new Pizza() { Id = 3, Name = "DaVinci Pizzas"},
		new Pizza() { Id = 4, Name = "Michelangello"},
		new Pizza() { Id = 5, Name = "Rafaelle"},
	};

	//Mètodo getter que retorna la lista de pizzas
	// GET API REGISTRO DE PIZZAS
	public static List<Pizza> GetPizzas()
	{
		return _pizzas;
	}

	// MÈTODO CON PARÀMETROS PARA  UBICAR ID ESPECÌFICO
	public static Pizza? GetPizza(int id)
	{
		return _pizzas.SingleOrDefault(pizza => pizza.Id == id);
	}


	// MÈTODO PUT PARA CREAR UN NUEVO ELEMENTO Y ADHERIR A LA DATABASE
	public static Pizza? CreatePizza(Pizza pizza)
	{
		_pizzas.Add(pizza);
		return pizza;
	}

	// UPDATE, CAMBIA DE FORMA CONSSTENTE A SPRING !!!

	public static Pizza UpdatePizza(Pizza update)
	{// UPDATE *** ADMITE LAMBDAS Y SELECTS PARA FILTRAR Y ACTUALIZAR EL ELEMENTO ESPECÌFICO ***
		_pizzas = _pizzas.Select(pizza =>
		{
			if (pizza.Id == update.Id)
			{
				pizza.Name = update.Name;
			}
			return pizza;
		}).ToList();
		return update;
	}

	public static void RemovePizza(int id)
	{
		_pizzas = _pizzas.FindAll(pizza => pizza.Id == id).ToList();
	}
}