window.sessionStorageHelper = {
    setItem: (key, value) => sessionStorage.setItem(key, JSON.stringify(value)),
    getItem: (key) => {
        const value = sessionStorage.getItem(key);
        return value ? JSON.Parse(value) : null;
    },
    removeItem: (key) => sessionStorage.removeItem(key),
    clear: () => sessionStorage.clear()
}