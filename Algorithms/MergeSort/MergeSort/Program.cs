var a = new[] { 5, 8, 51, 12, 56, 7, 9, 45, 11 };

MergeSort(a, a.Length);

foreach (var item in a)
    Console.WriteLine(item);

void MergeSort(int[] arr, int len)
{
    if (len <= 1)
        return;
    
    int half = len / 2;

    int lenghtA = half;
    int lengthB = len % 2 == 0 ? half : len - half; // if length is odd
    
    // Create 2 halves
    int[] arrA = new int[lenghtA];
    int[] arrB = new int[lengthB]; 

    Array.Copy(arr, 0, arrA, 0, lenghtA);
    Array.Copy(arr, half, arrB, 0, lengthB);

    // recursive
    MergeSort(arrA, lenghtA);
    MergeSort(arrB, lengthB);

    // merge
    Merge(arrA, lenghtA, arrB, lengthB, arr);
}

void Merge(int[] arrA, int lenA, int[] arrB, int lenB, int[] sorted)
{
    int i = 0, j = 0, z = 0;

    // merge the two arrays
    while (i < lenA && j < lenB)
    {
        if (arrA[i] <= arrB[j])
        {
            sorted[z] = arrA[i];
            i++;
        }
        else
        {
            sorted[z] = arrB[j];
            j++;
        }

        z++;
    }
    
    // pick remaining items
    while (i < lenA)
    {
        sorted[z] = arrA[i];
        i++;
        z++;
    }
    while (j < lenB)
    {
        sorted[z] = arrB[j];
        j++;
        z++;
    }
}