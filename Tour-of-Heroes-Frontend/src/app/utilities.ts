import { HttpHeaders } from '@angular/common/http';

class Object {
    public id: number;
}

class Utilities {
    public static apiServerUrl =  'https://localhost:44393';
    public static httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    public static getUniqueId(newId: number, objects: Object[]): number {
        objects.forEach(object => {
            if (object.id) {
                if (object.id === newId) {
                    return Utilities.getUniqueId(newId + 1, objects);
                }
            }
        });

        return newId;
    }
}

export { Utilities, Object };
