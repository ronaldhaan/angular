import { Ability } from './ability';

/** represents a hero. */
export class Metahuman {
    id: string;
    name: string;
    abilities: Ability[];

    public static Empty(): Metahuman {
        return {
            id: '',
            name: '',
            abilities: [],
          };
    }
}
