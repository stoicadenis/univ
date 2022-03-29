#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void schimbare(char a[20][30], int k){
    char aux[10];
    int i,j;
for(i=0;i<k;i++)
        for(j=i+1;j<=k;j++)
    {
        if(strcmp(a[i],a[j])>0){
            strcpy(aux,a[i]);
            strcpy(a[i],a[j]);
            strcpy(a[j],aux);
        }
    }
}

int main() {
	char s[100], a[20][30], * p, * sep = " ";
	int k = 0, i, j;
	fgets(s, 100, stdin);
	p = strtok(s, sep);
	while (p != NULL)
	{
		strcpy(a[k], p);
		k++;
		p=strtok(NULL, sep);
	}
	strcpy(a[k],"\0");
	for (i = 0; i <= k; i++)
		printf("%s ", a[i]);
    schimbare(a,k);
    printf("Textul ordonat este:\n");
    for (i = 0; i <= k; i++)
		printf("%s ", a[i]);
	return 0;
}
