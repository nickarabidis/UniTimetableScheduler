# University Class Scheduler

## Description
The University Class Scheduler Software is a software for the automatic generation of a timetable with the specific requirements for the needs of a University.
The software is built with C#, .NET framework and SQLite.

The software uses:
 - A Genetic Algorithm to generate a timetable with the requirements and criteria from the University.
 - A Database so the data of the courses, professors, semesters, days, start times, rooms and more are stored and used from there.
 - An Interface with Window Forms so it can be a user friendly and efficient tool.

## General Software Operation
You can see how the software works from the UI to the Genetic Algorithm to the Solution, from the below diagram.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/421b7f22-f30d-45af-93f8-660f766ef730)

The timetable chromosome is represented by a time slot for each hour, every semester and every day with a hash code (day * 14(total hours) * 4 + semester * 14(total hours) + time) and the maximum hashcode in the time slot is 280. 
While the algorithm is running, it assigns the courses to those time slots from the start of the genetic algorithm until the solution.

## Requirements
The general requirements:
- Course hours can begin from 8am and finish 22pm (8:00 - 22:00) so in total there are 14 hours for each day.
- The days of the timetable are from Monday to Friday so in total there are 5 days per semester.
- There are in total 4 semesters in the timetable.
- The class rooms are divided into two categories the theory rooms and the laboratory rooms, for the respective courses.

The requirements used by the algorithm:
- There shouldn't be overlapping with hours of theory courses in the same semester and there should be the possibility of overlapping hours with only two laboratory courses.
- There shouldn't be overlapping with hours of the teachers' lessons on the same day.
- There shouldn't be overlapping with classroom hours that teach courses on the same day.
- No class for assembly teachers on Thursday 10:00 – 12:00.
- There is at least one free hour between 12:00 – 16:00 for all semesters every day.
- There is at least one lesson per day to properly spread the lessons in the timetable.
- It is possible to introduce a teachers' preference for a classroom, day, or start time.
- It is possible to introduce a dependency between courses, to teach a teacher's courses on the same day, on different days, or on a number of days.
  
The requirements for this software are **Hard** requirements (they all need to be met without exception for a solution).

## Features
For each window there's the possibility of Adding, Updating, Deleting, Deleting All and Printing in a txt file, data from the database.

Courses:
- Add/Update and Delete a **Course** with its data to/from the database.
- Delete All **Course** data from the database.
- Print **Course** data from the database.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/f01cef81-9ce8-44bb-81d9-6ffa71b79b49)


Professors:
- Add/Update and Delete a **Professor** with its data to/from the database.
- Delete All **Professor** data from the database.
- Print **Professor** data from the database.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/b5a5d482-f88f-4796-bbfc-bbfe66a3f2e5)


Rooms:
- Add/Update and Delete a **Room** with its data to/from the database.
- Delete All **Room** data from the database.
- Print **Room** data from the database.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/523642a1-397c-4d6b-b6be-3e642d8c444a)


Periods:
- Add/Update and Delete a **Semester**/**Day**/**Start Time** with its data to/from the database.
- Delete All **Semester**/**Day**/**Start Time** data from the database.
- Print **Semester**/**Day**/**Start Time** data from the database.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/b30abb96-346a-47c3-baf9-54e018e8c4a0)


Preferences:
- Add/Update and Delete a **Preferred Day**/**Preferred Start Time**/**Preferred Room** with its data to/from the database.
- Delete All **Preferred Day**/**Preferred Start Time**/**Preferred Room** data from the database.
- Print **Preferred Day**/**Preferred Start Time**/**Preferred Room** data from the database.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/80d36f86-198b-4faf-a84f-64b889b923b8)


Dependencies:
- Add/Update and Delete a **Dependency** with its data to/from the database.
- Delete All **Dependency** data from the database.
- Print **Dependency** data from the database.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/23c0286a-025f-4b18-ae0f-7a01e66a7e28)


Scheduler:
- Add/Update and Delete a **Scheduler** with its data to/from the database.
- Delete All **Scheduler** data from the database.
- Print **Scheduler** data from the database.
- Print All data from the database to one file.
- Generate the timetable with the genetic algorithm.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/fb017e0c-be9f-4742-81ac-473932ab8e9e)

Generated Schedule:
- Shows the generated schedule and the data.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/550ea984-d498-4559-b76c-541aa3369953)

Generated Timetable:
- Shows the generated timetable on a browser with HTML.

![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/48970d05-8748-462f-a787-06d3c7405db3)
![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/05f0f7aa-8d52-4b69-a9e2-dbe2e1bbb5d8)
![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/02c421a6-17e7-480f-9975-4a754c3424fe)
![image](https://github.com/nickarabidis/UniTimetableScheduler/assets/75751845/edb96cfc-4f21-4c27-9072-22f8148ff89e)


## Licence
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Released under the [MIT](https://github.com/nickarabidis/UniTimetableScheduler/blob/main/LICENSE) License.
