#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct Queue
{
    int bottom;
    int top;
    int capacity;
    int* array;
};

struct Queue* initialize(int capacity)
{
    struct Queue* queue = (struct Stack*)malloc(sizeof(struct Queue));
    queue->capacity = capacity;
    queue->bottom = -1;
    queue->top = -1;
    queue->array = (int*)malloc(queue->capacity * sizeof(int));
    return queue;
}

int is_empty(struct Queue* queue)
{
    return queue->top == queue->bottom;
}

int is_full(struct Queue* queue)
{
    return (queue->bottom == queue->top + 1) || (queue->bottom == 0 && queue->top == queue->capacity - 1);
}

void push(struct Queue* queue, int element)
{
    if (is_full(queue))
    {
        printf("Queue is full!\n");
    }
    else
    {
        if (queue->bottom == -1)
            queue->bottom = 0;

        queue->top = (queue->top + 1) % queue->capacity;
        queue->array[queue->top] = element;
        printf("Element %d added to the queue.\n", queue->array[queue->top]);
    }
}

int pop(struct Queue* queue)
{
    if (is_empty(queue))
    {
        printf("The queue is empty!\n");
        queue->bottom = -1;
            queue->top = -1;
    }
    else
    {
        printf("Element %d popped from the queue.\n", queue->array[queue->bottom]);
        int popped = queue->array[queue->bottom];
        queue->bottom = (queue->bottom + 1) % queue->capacity;
        return popped;
    }
}

void print_elements(struct Queue* queue)
{
    if (is_empty(queue))
    {
        printf("Empty queue!");
    }
    else
    {
        for (int i = queue->bottom; i != (queue->top); i = (i + 1) % queue->capacity)
            printf("Element %d is %d\n", i, queue->array[i]);

        printf("Element %d is %d\n", queue->top, queue->array[queue->top]);
    }
}

int main()
{
    struct Queue* queue = initialize(4);
    push(queue, 2);
    push(queue, 6);
    push(queue, 4);
    push(queue, 8);
    push(queue, 9);
    pop(queue);
    pop(queue);
    push(queue, 9);
    push(queue, 6);
    pop(queue);
    print_elements(queue);
}
