This is a solution for Dining Philosophers Problem (deadlock)

https://en.wikipedia.org/wiki/Dining_philosophers_problem

Algorithm for each of the philosophers (using monitor):

Think unless the left fork is available; when it is, pick it up; Check if right fork can be picked up; when it is; pick it up; otherwise put left fork down; When both forks are held, eat for a fixed amount of time; Put the left fork down; Put the right fork down; Repeat from the beginning unit everyone eats 5 times;
