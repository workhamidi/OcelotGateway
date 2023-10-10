
1. create "ocelot.json" file 


2. isatall the "Ocelot" package 


3. add json file 
'''
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot(builder.Configuration);
'''

and to  pipeline midelware

'''
app.UseOcelot()
    .Wait();
'''

