const ensureDelete = (animalName: string): boolean => {
    if (confirm(`are you sure you want to delete ${animalName}?`)) {
        return true;
    } else {
        return false;
    }
}

