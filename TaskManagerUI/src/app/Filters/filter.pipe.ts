import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name:'filter'
})
export class FilterPipe implements PipeTransform{
    transform(items: any[],field:string, searchText: string):any[] {
        if(!items) return [];
        if(!field || !searchText) return items;
        searchText=searchText.toLowerCase();
        return items.filter(it=>{
            return it[field].toLowerCase().includes(searchText.toLowerCase());
        });
    }    
}