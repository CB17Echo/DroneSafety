﻿/**
 * Copyright 2017 Joshua Blake
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 **/

using System;

public static void Run(TimerInfo myTimer, out object timeValue, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    Random rng = new Random();
    int value = rng.Next();
    log.Info($"Value is: {value}");
    timeValue = new
    {
        time = DateTime.Now,
        value = value
    };
}