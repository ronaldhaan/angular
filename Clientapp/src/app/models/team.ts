import { Metahuman } from './metahuman';

/** represents a hero. */
export class Team {
    id: string;
    name: string;
    metahumans: Metahuman[];

    public static Empty(): Team {
        return {
            id: '',
            name: '',
            metahumans: [],
        };
    }
}
