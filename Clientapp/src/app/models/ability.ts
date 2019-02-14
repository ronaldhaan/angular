import { Metahuman } from './metahuman';

export class Ability {
    id: string;
    name: string;
    description: string;
    metas: Metahuman[];

    public static Empty(): Ability {
        return {} as Ability;
    }
}
