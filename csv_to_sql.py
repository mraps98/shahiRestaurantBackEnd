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
	#	line = line.strip("\n")
	#	print(line)
	#	f.write("insert into FoodItems values(" + line + ");\n")	
