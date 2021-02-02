with open("menu.csv", "r") as f:
	lines = f.readlines()

lines.pop(0)

with open("resetDatabase.sql", "w") as f:
	f.write("delete from FoodItems;\n")
	for line in lines:
		line = line.strip("\n")
		count = 0 
		f.write("insert into FoodItems (Name, Category, Price, SpiceLevel, IsVegetarian) values(")
		for word in line.split(", ")					:
			if count == 0:
				f.write("\"" + word + "\", ")
			else:
				f.write(word)
				if count < 4:
					f.write(", ")	
			count = count + 1
		f.write(");")
		f.write("\n")
	f.write("delete from Categories;\n")
	f.write('insert into Categories values(0, "Bread");\n');
	f.write('insert into Categories values(1, "Appetizer");\n');
	f.write('insert into Categories values(2, "Main Course");\n');
	f.write('insert into Categories values(3, "Desert");\n');
	f.write('insert into Categories values(4, "Beverage");\n');