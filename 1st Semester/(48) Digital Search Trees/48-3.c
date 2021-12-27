#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct DSNode
{
	int key;
	int data;
	struct DSNode* left, * right;
};

int digit(int number, int key)
{
	key = key >> number;
	return key % 2;
}

struct DSNode* search(struct DSNode* root, int key)
{
	if (!root)
		return NULL;
	if (root->key == key)
		return root;

	int keyCopy = key;
	while (!root || root->key != key)
	{
		if (keyCopy % 2 == 0)
			root = root->left;
		else
			root = root->right;

		keyCopy >> 1;
	}

	if (root->key == key)
		return root;
	else
		return NULL;
}

struct DSNode* searchRecursively(struct DSNode* root, int key, int count)
{
	if (!root)
		return NULL;

	if (root->key == key)
	{
		return root;
	}
	else
	{
		if (digit(key, count) == 0)
		{
			return searchRecursively(root->left, key, count + 1);
		}
		else
		{
			return searchRecursively(root->right, key, count + 1);
		}
	}
}

int main()
{

}
