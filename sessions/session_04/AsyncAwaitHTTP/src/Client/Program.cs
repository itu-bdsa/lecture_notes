﻿// Create an HTTP client object
var baseURL = "http://localhost:5088";
using HttpClient client = new();
client.BaseAddress = new Uri(baseURL);

// Sequential execution
var watch = System.Diagnostics.Stopwatch.StartNew();
// first HTTP request
var fstResponse = await client.GetAsync("/");
// second HTTP request
var sndResponse = await client.GetAsync("/");
watch.Stop();

Console.WriteLine($"Sequential HTTP requests ... done after {watch.ElapsedMilliseconds}ms");

// Concurrent execution
watch = System.Diagnostics.Stopwatch.StartNew();
// first HTTP request
var fstRequestTask = client.GetAsync("/");
// second HTTP request
var sndRequestTask = client.GetAsync("/");

var thrdResponse = await fstRequestTask;
var frthResponse = await sndRequestTask;
watch.Stop();

Console.WriteLine($"Concurrent HTTP requests ... done after {watch.ElapsedMilliseconds}ms");
