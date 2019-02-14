import { Ability } from './ability';
import {Team} from './team';

/** represents a meta. */
export class Metahuman {
    id: string;
    name: string;
    description: string;
    alterEgo: string;
    abilities: Ability[];
    status: number;
    teams: Team[];

    public static Empty(): Metahuman {
        return {
            id: '',
            name: '',
            description: '',
            alterEgo: '',
            abilities: [],
            status: 0,
            teams: []
          };
    }
}
