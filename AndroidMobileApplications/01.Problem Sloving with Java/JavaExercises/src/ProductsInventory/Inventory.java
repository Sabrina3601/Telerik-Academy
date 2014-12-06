package ProductsInventory;

//import java.util;
import java.util.ArrayList;
import java.util.List;

java.util.List



public class Inventory {
	List<Product> products;
	
	public Inventory(){
		this.products = new ArrayList<Product>();
	}
	
	public void Add(Product product){
		this.products.add(product);
	}
	
	public double Sum(){
		double sum = 0;
		
		for (int i = 0; i < this.products.size(); i++) {
			
			sum += this.products.get(i).Price;
		}
		
		return sum;
	}
}
