var ensureDelete = function (animalName) {
    if (confirm("are you sure you want to delete ".concat(animalName, "?"))) {
        return true;
    }
    else {
        return false;
    }
};
