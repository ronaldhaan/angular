import { Metahuman } from './metahuman';

export class Ability {
    id: string;
    name: string;
    description: string;
    heroes: Metahuman[];

    public static Empty(): Ability {
        return {
            id: '',
            name: '',
            description: '',
            heroes: []
          };
    }
}
