using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

if (args.Length != 1)
{
    PrintHelp();
    return;
}

using HttpClient client = new HttpClient();
var requestUri = $"https://swapi.dev/api/people/?search={args[0]}";
var response = await client.GetFromJsonAsync<PersonsDTO>(requestUri);

if (response?.Count != 1)
{
    Console.WriteLine("There is no single answer to your question!");
}
else
{
    foreach (var person in response.Results)
    {
        Console.WriteLine($"{person.Name} was born {person.Birth_Year}.");
    } 
}

void PrintHelp()
{
    Console.WriteLine("Not enough arguments. Exit program");
}

record PersonDto (string Name, string Birth_Year);

record PersonsDTO (int Count, IList<PersonDto> Results);