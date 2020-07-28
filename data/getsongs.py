import json
sets = set()
j = json.load(open('songlist', encoding='utf8'))
for song in j["songs"]:
    
    if 'purchase' in song.keys():
        sets.add(song['purchase'])
    
print(sets)